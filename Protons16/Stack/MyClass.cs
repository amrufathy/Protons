namespace StackSession
{
    public class MyClass
    {
        private string myField;

        private int operationCount; // Tells the number of changes done to the property
        private int myIntPropertyBackingField;

        public int MyIntProperty
        {
            get { return myIntPropertyBackingField; }
            set
            {
                // Increment the number of operations done to this property
                operationCount++;

                // Set the value of the property
                myIntPropertyBackingField = value;
            }
        }

        public int OperationCount
        {
            // This property is read only, no one from outside the class can change its value
            get { return myIntPropertyBackingField; }
        }

        public string MyAutomaticProperty { get; set; }
    }
}