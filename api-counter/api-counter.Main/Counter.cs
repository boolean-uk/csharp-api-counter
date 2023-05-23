namespace api_counter
{
    public class Counter
    {
        private int _value;
        private string _name;

        public Counter(int value)
        {
            Value = value;
        }

        public Counter(int value, string name)
        {
            Value = value;
            Name = name;
        }
        // @TODO Create int property called Value holding the counter value
        // @EXTENSIONS @TODO Create string property called Name holding the counter name 

        public int Value { get { return _value; } set { _value = value; } }
        public string Name { get { return _name; } set { _name = value; } }
    }
}
