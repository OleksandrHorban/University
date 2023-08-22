public delegate void NameChangeEventHandler(object sender, NameChangeEventArgs args);

class Dispatcher
{
    string name = "No name";

    public string Name
    {
        get => name;
        set
        {
            name = value;
            OnNameChange(new NameChangeEventArgs(Name));
        }
    }

    public event NameChangeEventHandler? NameChange;

    public void OnNameChange(NameChangeEventArgs args)
    {
        NameChange?.Invoke(new object(), args);
    }
}


