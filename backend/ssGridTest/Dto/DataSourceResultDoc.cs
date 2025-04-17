using Kendo.Mvc.UI;

namespace ssGridTest.Dto
{
    /// <summary>
    /// Kendo typový datasourceresult - generický datový typ pro dokumentační účely swageru - nahraď typ očekavaným návratovým typem
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class DataSourceResultDoc<T> : DataSourceResult where T : class
    {
        /// <summary>
        /// overide kendích dat
        /// </summary>
        public new IEnumerable<T> Data
        {
            get => base.Data.Cast<T>();
            set => base.Data = value;
        }
    }
}
