namespace GridSeverSideDemo.Dto
{
    public class ProductDto
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
        public DateOnly AddedDate { get; set; }

        /// <summary>
        /// Značka produktu
        /// </summary>
        public string Brand { get; set; } = string.Empty;
    }
}
