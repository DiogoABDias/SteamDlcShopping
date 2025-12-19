namespace SteamDlcShopping.App.Extensibility;

internal class ListViewPlus : ListView
{
    internal ColumnSorter? _columnSorter;

    internal protected void Unload(bool resetHeaders)
    {
        Items.Clear();
        ListViewItemSorter = null;

        if (resetHeaders)
        {
            ResetHeaders();
        }
    }

    internal protected void ResetHeaders()
    {
        foreach (ColumnHeader column in Columns)
        {
            if (column.Tag is null)
            {
                continue;
            }

            if (!int.TryParse(column.Tag.ToString(), out int length))
            {
                continue;
            }

            column.Text = column.Text[..length];
        }
    }

    internal void SortList(int newColumn, bool revertSorting = true)
    {
        if (newColumn == -1)
        {
            return;
        }

        if (_columnSorter is null)
        {
            return;
        }

        //Remove sorting characters from the previous column
        if (_columnSorter.Column >= 0 && Columns[_columnSorter.Column].Tag is not null && int.TryParse(Columns[_columnSorter.Column].Tag?.ToString(), out int length))
        {
            Columns[_columnSorter.Column].Text = Columns[_columnSorter.Column].Text[..length];
        }

        //Store column title length in order to add and remove sorting characters
        if (Columns[newColumn].Tag is null)
        {
            Columns[newColumn].Tag = Columns[newColumn].Text.Length;
        }

        if (revertSorting)
        {
            //Revert sorting on the same column
            if (newColumn == _columnSorter.Column)
            {
                _columnSorter.Order = _columnSorter.Order == SortOrder.Ascending ? SortOrder.Descending : SortOrder.Ascending;
            }
            else
            {
                _columnSorter.Column = newColumn;
                _columnSorter.Order = SortOrder.Ascending;
            }
        }

        //Apply the sorting character
        switch (_columnSorter.Order)
        {
            case SortOrder.Ascending:
                Columns[_columnSorter.Column].Text += " ▲";
                break;
            case SortOrder.Descending:
                Columns[_columnSorter.Column].Text += " ▼";
                break;
            case SortOrder.None:
                break;
        }

        Sort();
    }
}