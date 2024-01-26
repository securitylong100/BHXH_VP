using Newtonsoft.Json;
using System;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using XML130.Libraries;

namespace XML130.XML
{
    public class ClientHelper
    {
        private const string HEADER_TOKENID = "tokenId";
        private const string HEADER_ACCESS_TOKEN = "accessToken";
        private const string HEADER_PASSWORDHASH = "passwordHash";
        private readonly HttpClient _client = new HttpClient();
        private static readonly Lazy<ClientHelper> _instance = new Lazy<ClientHelper>();

        public static ClientHelper Instance => _instance.Value;

        /// <summary>
        /// Đăng nhập API để lấy token và lưu vào default header của httpclient
        /// </summary>
        /// <param name="username"></param>
        /// <param name="password"></param>
        /// <returns></returns>
        public string Login(string username, string password, Action<string, bool> callback = null)
        {
            password = EasyEncoding.SHA1MD5.MD5Hasn(password).ToUpper();
            string jsonContent = JsonConvert.SerializeObject(new { username, password });
            StringContent content = new StringContent(jsonContent, encoding: Encoding.UTF8, mediaType: "application/json");
            Task<HttpResponseMessage> responseTask = Task.Run(async () =>
                await _client.PostAsync("https://daotaoegw.baohiemxahoi.gov.vn/api/token/take", content).ConfigureAwait(false)
            );
            while (!responseTask.IsCompleted) { }
            HttpResponseMessage responseMsg = responseTask.Result;
            if (responseMsg.IsSuccessStatusCode)
            {
                Task<string> contentTask = Task.Run(async () => await responseMsg.Content.ReadAsStringAsync());
                while (!contentTask.IsCompleted) { }
                LoginResponse response = JsonConvert.DeserializeObject<LoginResponse>(contentTask.Result);
                if (response.maKetQua == "200")
                {
                    _client.DefaultRequestHeaders.Add(HEADER_ACCESS_TOKEN, response.APIKey.access_token);
                    _client.DefaultRequestHeaders.Add(HEADER_TOKENID, response.APIKey.id_token);
                    _client.DefaultRequestHeaders.Add(HEADER_PASSWORDHASH, password);
                    callback?.Invoke(string.Format("Username: {0} đăng nhập thành công", username), true);
                    return username;
                }
            }
            callback?.Invoke(string.Format("Username: {0} đăng nhập thất bại", username), false);
            return string.Empty;
        }

        /// <summary>
        /// Gửi file Xml đã được mã hóa Base64
        /// </summary>
        /// <param name="request"></param>
        /// <param name="callback"></param>
        /// <returns></returns>
        public bool SendBase64Xml(SendXmlRequest request, Action<string, bool> callback = null)
        {
            if (!_client.DefaultRequestHeaders.Contains(HEADER_ACCESS_TOKEN))
            {
                callback?.Invoke("Chưa đăng nhập", false);
                return false;
            }
            string jsonString = JsonConvert.SerializeObject(request);
            StringContent content = new StringContent(jsonString, Encoding.UTF8, "application/json");
            Task<HttpResponseMessage> responseTask = Task.Run(
                async () => await _client.PostAsync("https://daotaoegw.baohiemxahoi.gov.vn/api/qd130/guiHoSoXmlQD130", content).ConfigureAwait(false)
            );
            while (!responseTask.IsCompleted) { }
            HttpResponseMessage responseMsg = responseTask.Result;
            if (responseMsg.IsSuccessStatusCode)
            {
                Task<string> contentTask = Task.Run(async () => await responseMsg.Content.ReadAsStringAsync());
                while (!contentTask.IsCompleted) { }
                SendXmlResponse response = JsonConvert.DeserializeObject<SendXmlResponse>(contentTask.Result);
                bool isOk = response.maKetQua == "200";
                StringBuilder sb = new StringBuilder();
                sb.AppendFormat("Kết quả: {0}\n", response.maKetQua);
                sb.AppendFormat("Mã giao dịch: {0}\n", response.maGiaoDich);
                sb.AppendFormat("Thông điệp: {0}\n", response.thongDiep);
                sb.AppendFormat("Thời gian tiếp nhận: {0}\n", response.thoiGianTiepNhan);
                callback?.Invoke(sb.ToString(), isOk);
                return isOk;
            }
            return false;
        }

        public class LoginResponse
        {
            public string maKetQua { get; set; }
            public LoginResult APIKey { get; set; }
        }

        public class LoginResult
        {
            public string access_token { get; set; }
            public string id_token { get; set; }
            public string token_type { get; set; }
            public string username { get; set; }
            public DateTime expires_in { get; set; }
        }

        public class SendXmlRequest
        {
            public string username { get; set; }
            public string loaiHoSo { get; set; } = "130";
            public string maTinh { get; set; } = "26";
            public string maCSKCB { get; set; } = "26001";
            public string fileHSBase64 { get; set; }
        }

        public class SendXmlResponse
        {
            public string maKetQua { get; set; }
            public string maGiaoDich { get; set; }
            public string thoiGianTiepNhan { get; set; }
            public string thongDiep { get; set; }
        }
    }
}
