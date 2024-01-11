using System.Collections.Generic;
using DevExpress.Data;
using DevExpress.Data.Filtering;
using DevExpress.Data.Filtering.Helpers;
using DevExpress.XtraGrid;
using DevExpress.XtraGrid.Columns;
using DevExpress.XtraGrid.Registrator;
using DevExpress.XtraGrid.Views.Base;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraGrid.Views.Grid.Drawing;
using DevExpress.XtraGrid.Views.Grid.ViewInfo;

namespace XML130.CustomGridLookUpEdit
{
    public class CustomGridView : GridView
    {
        protected override string ViewName
        {
            get { return "CustomGridView"; }
        }

        protected internal virtual string GetExtraFilterText
        {
            get { return ExtraFilterText; }
        }

        protected internal virtual void SetGridControlAccessMetod(GridControl newControl)
        {
            SetGridControl(newControl);
        }

        protected override string OnCreateLookupDisplayFilter(string text, string displayMember)
        {
            var subStringOperators = new List<CriteriaOperator>();
            foreach (var sString in text.Split(' '))
            {
#pragma warning disable 618
                var exp = LikeData.CreateContainsPattern(sString);
#pragma warning restore 618

                var columnsOperators = new List<CriteriaOperator>();
                foreach (GridColumn col in Columns)
                {
                    if (col.Visible && col.ColumnType == typeof (string))
                    {
#pragma warning disable 618
                        columnsOperators.Add(new BinaryOperator(col.FieldName, exp, BinaryOperatorType.Like));
#pragma warning restore 618
                    }
                    else if (col.Visible && col.ColumnType == typeof (int))
                    {
#pragma warning disable 618
                        columnsOperators.Add(new BinaryOperator(col.FieldName, exp, BinaryOperatorType.Like));
#pragma warning restore 618
                    }
                }
                subStringOperators.Add(new GroupOperator(GroupOperatorType.Or, columnsOperators));
            }
            return new GroupOperator(GroupOperatorType.And, subStringOperators).ToString();
        }
    }

    public class CustomGridControl : GridControl
    {
        protected override void RegisterAvailableViewsCore(InfoCollection collection)
        {
            base.RegisterAvailableViewsCore(collection);
            collection.Add(new CustomGridInfoRegistrator());
        }

        protected override BaseView CreateDefaultView()
        {
            return CreateView("CustomGridView");
        }
    }

    public class CustomGridPainter : GridPainter
    {
        public CustomGridPainter(GridView view) : base(view)
        {
        }

        public new virtual CustomGridView View
        {
            get { return (CustomGridView) base.View; }
        }

        protected override void DrawRowCell(GridViewDrawArgs e, GridCellInfo cell)
        {
            cell.ViewInfo.MatchedStringUseContains = true;
            cell.ViewInfo.MatchedString = View.GetExtraFilterText;
            cell.State = GridRowCellState.Dirty;
            e.ViewInfo.UpdateCellAppearance(cell);
            base.DrawRowCell(e, cell);
        }
    }

    public class CustomGridInfoRegistrator : GridInfoRegistrator
    {
        public override string ViewName
        {
            get { return "CustomGridView"; }
        }

        public override BaseViewPainter CreatePainter(BaseView view)
        {
            return new CustomGridPainter(view as GridView);
        }

        public override BaseView CreateView(GridControl grid)
        {
            var view = new CustomGridView();
            view.SetGridControlAccessMetod(grid);
            return view;
        }
    }
}