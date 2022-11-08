namespace Data.ForSchool.WritingAndDrawing
{
    public class WritingUtensilsType
    {
        private string name;

        public WritingUtensilsType(string name)
        {
            Name = name;
        }

        public string Name
        {
            get { return name; }
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException("Name cannot be null or empty!");
                }
                name = value;
            }
        }
    }
}
