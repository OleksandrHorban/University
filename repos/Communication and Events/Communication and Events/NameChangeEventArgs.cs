public class NameChangeEventArgs : EventArgs
{
    public string Name { get; private set; } = "";

    public NameChangeEventArgs(string name) => Name = name;
}
