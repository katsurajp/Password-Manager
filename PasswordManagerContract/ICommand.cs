namespace Password_Manager.Contract {
    public interface ICommand {
        bool CanUndo { get; }

        object Execute();

        object Undo();

        object Redo();
    }
}
