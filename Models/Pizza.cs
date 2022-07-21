namespace Pizza.Models
{
    /// <summary>
    /// Pizza data model consist of id, name and whether is it gluten free
    /// </summary>
    public class Pizza
    {

        /// <summary>
        /// ID {int} field getter setter
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Name {String} field getter setter
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// GlutenFree {bool} getter setter
        /// </summary>
        public bool IsGlutenFree { get; set; }
    }
}
