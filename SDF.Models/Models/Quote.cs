namespace SDF.Models.Models
{
    public class Quote
    {       
        public Guid Guid { get; set; }
        public string Text { get; set; }
        public string Author { get; set; }

        public Quote()
        {
            Guid = Guid.NewGuid();
        }

        //[OnDeserialized]
        //private void OnDeserialized(StreamingContext context)
        //{
        //    Guid = Guid.NewGuid();
        //}
    }
}
