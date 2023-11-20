using KODEPROEX1.Entities.Queries;
using KODEPROEX1.Implementation.Interfaces;

namespace KODEPROEX1;

public partial class Form1 : Form
{
    
    private readonly IStudentRepo _studentRepository;       // Repo - Handle the operations in the BD
    private readonly DataGridView _dataGridViewEstudiantes;
    private readonly TextBox _searchTextBox;
    private readonly Button _searchButton;
    
    public Form1(IStudentRepo studentRepository)
    {
        _studentRepository = studentRepository;
        
        InitializeComponent();
        
        // Configure TextBox
        _searchTextBox = new TextBox
        {
            Name = "searchTextBox",
            PlaceholderText = "Enter search criteria... (m/d/yyyy format for dates search)",
            Dock = DockStyle.Fill,
        };

        // Configure Button
        _searchButton = new Button
        {
            Name = "searchButton",
            Text = "Search",
            Dock = DockStyle.Fill,
        };
        _searchButton.Click += SearchButton_Click;

        // Create and configure the DataGridView
        _dataGridViewEstudiantes = new DataGridView
        {
            Name = "dataGridViewEstudiantes",
            Dock = DockStyle.Fill,
        };
        
        var tableLayoutPanel = new TableLayoutPanel
        {
            Dock = DockStyle.Fill,
        };
        
        // Set padding to display our form in the way that we eant
        tableLayoutPanel.RowStyles.Add(new RowStyle(SizeType.Absolute, _searchTextBox.Height + 5));
        tableLayoutPanel.RowStyles.Add(new RowStyle(SizeType.Absolute, _searchButton.Height + 15));
        tableLayoutPanel.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));

        // Adding our elements to the form
        tableLayoutPanel.Controls.Add(_searchTextBox, 0, 0);
        tableLayoutPanel.Controls.Add(_searchButton, 0, 1);
        tableLayoutPanel.Controls.Add(_dataGridViewEstudiantes, 0, 2);

        Controls.Add(tableLayoutPanel);
        
        // Firstly load our students list
        Load += FormEstudiantes_Load;
    }
    
    private void FormEstudiantes_Load(object sender, EventArgs e)
    {
        try
        {
            // We load all stundents in the BD
            var students = _studentRepository.GetStudentsByFilters(null);
            _dataGridViewEstudiantes.DataSource = students;
        }
        catch (Exception ex)
        {
            MessageBox.Show("Error loading student data: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            Console.WriteLine(ex.Message);
        }
    }
    
    
    private void SearchButton_Click(object sender, EventArgs e)
    {
        var searchTerm = _searchTextBox.Text.Trim();
        var searchQuery = new GetStudentsByFiltersQry ();
        
        // Our search includes  >, >=, =<, or <
        if (searchTerm.Contains('<'))
        {
            // If special characters detected, extract the date and set LessThen in the query
            if (DateTime.TryParse(searchTerm.Replace("<=", "").Replace("<", "").Trim(), out var lessThanDate))
            {
                searchQuery.LessThan = lessThanDate;
            }
        }
        else if (searchTerm.Contains('>'))
        {
            // If special characters detected, extract the date and set GreaterThan in the query
            if (DateTime.TryParse(searchTerm.Replace(">=", "").Replace(">", "").Trim(), out var greaterThanDate))
            {
                searchQuery.GreaterThan = greaterThanDate;
            }
        }
        else
        {
            searchQuery.SearchTerm = searchTerm;
        }
        
        var filteredStudents = _studentRepository.GetStudentsByFilters(searchQuery);
        _dataGridViewEstudiantes.DataSource = filteredStudents;
    }
}