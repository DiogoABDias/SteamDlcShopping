using System.Collections;

namespace SteamDlcShopping.App.Extensibility;

public class ColumnSorter : IComparer
{
    //Fields
    private int _column;

    private SortOrder _order;

    private readonly CaseInsensitiveComparer _comparer;

    //Properties
    public int Column
    {
        get => _column;
        set => _column = value;
    }

    public SortOrder Order
    {
        get => _order;
        set => _order = value;
    }

    //Constructor
    public ColumnSorter()
    {
        _column = -1;
        _order = SortOrder.None;
        _comparer = new();
    }

    //Methods
    public int Compare(object? x, object? y)
    {
        if (_column == -1)
        {
            return 0;
        }

        ListViewItem? listviewX = (ListViewItem?)x;
        ListViewItem? listviewY = (ListViewItem?)y;
        int compareResult = 0;

        string? textX = listviewX?.SubItems[_column].Text;
        string? textY = listviewY?.SubItems[_column].Text;

        if (listviewX?.SubItems[_column].Tag is not Types type)
        {
            return 0;
        }

        switch (type)
        {
            case Types.String:
                compareResult = _comparer.Compare(textX, textY);
                break;
            case Types.Decimal:
                string digitsX = new(textX?.Where(char.IsDigit).ToArray());
                string digitsY = new(textY?.Where(char.IsDigit).ToArray());

                _ = decimal.TryParse(digitsX, out decimal decimalX);
                _ = decimal.TryParse(digitsY, out decimal decimalY);

                compareResult = _comparer.Compare(decimalX, decimalY);
                break;
        }

        return _order switch
        {
            SortOrder.Ascending => compareResult,
            SortOrder.Descending => -compareResult,
            _ => 0
        };
    }
}