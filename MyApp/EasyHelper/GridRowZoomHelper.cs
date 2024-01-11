using System;
using DevExpress.XtraGrid;
using DevExpress.XtraGrid.Views.BandedGrid;
using DevExpress.XtraGrid.Views.Grid;

namespace XML130.EasyHelper
{
    public class GridRowZoomHelper
    {
        public BandedGridView GridView { get; set; }

        public int ZoomedRowHeight { get; set; }
        private int _zoomedRowHandle;
        public int ZoomedRowHandle
        {
            get
            {
                return _zoomedRowHandle;
            }
            set
            {

                if (_zoomedRowHandle == value)
                    return;
                var prevValue = _zoomedRowHandle;
                _zoomedRowHandle = value;
                OnZoomedRowHandleChanged(prevValue, value);
            }
        }
        public GridRowZoomHelper(BandedGridView gridView)
        {

            GridView = gridView;
            
            ZoomedRowHeight = 60;
            ZoomedRowHandle = GridControl.InvalidRowHandle;
            GridView.RowClick += GridView_RowClick;
            GridView.CalcRowHeight += GridView_CalcRowHeight;
            GridView.ShownEditor += GridView_ShownEditor;
        }

        void GridView_ShownEditor(object sender, EventArgs e)
        {
            ZoomedRowHandle = GridView.FocusedRowHandle;
        }

        void GridView_CalcRowHeight(object sender, RowHeightEventArgs e)
        {
            if (e.RowHandle == ZoomedRowHandle)
                e.RowHeight = ZoomedRowHeight;
        }

        void GridView_RowClick(object sender, RowClickEventArgs e)
        {
            if (GridView.FocusedRowHandle < 0) return;
            ZoomedRowHandle = e.RowHandle;
        }

        private void OnZoomedRowHandleChanged(int prevValue, int value)
        {
            GridView.RefreshData();
        }
    }
}
