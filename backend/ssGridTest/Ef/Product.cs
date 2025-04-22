namespace GridSeverSideDemo.Ef
{
    public class Product
    {
        /// <summary>
        /// ID produktu
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Název produktu
        /// </summary>
        public string Name { get; set; } = string.Empty;

        /// <summary>
        /// Cena produktu
        /// </summary>
        public decimal Price { get; set; }

        /// <summary>
        /// Datum přidání produktu
        /// </summary>
        public DateTime AddedDate { get; set; }

        /// <summary>
        /// Značka produktu
        /// </summary>
        public string Brand { get; set; } = string.Empty;

        /// <summary>
        /// Tajná informace produktu
        /// </summary>
        public string SecretInfo { get; set; } = string.Empty;
    }
}
