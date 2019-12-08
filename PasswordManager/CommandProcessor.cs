using Password_Manager.Contract;
using System.Collections.Generic;

namespace Password_Manager {
    internal class CommandProcessor {
        private static readonly Stack<ICommand> _undoStack = new Stack<ICommand>();
        private static readonly Stack<ICommand> _redoStack = new Stack<ICommand>();

        public static bool CanUndo => _undoStack.Count > 0;

        public static bool CanRedo => _redoStack.Count > 0;

        public static object Execute(ICommand command) {
            object result = command.Execute();

            if (command.CanUndo)
                _undoStack.Push(command);

            _redoStack.Clear();

            return result;
        }

        public static object Undo() {
            object result = null;

            if(_undoStack.Count > 0) {
                ICommand command = _undoStack.Pop();
                result = command.Undo();
                _redoStack.Push(command);
            }

            return result;
        }

        public static object Redo() {
            object result = null;

            if(_redoStack.Count > 0) {
                ICommand command = _redoStack.Pop();
                result = command.Redo();
                _undoStack.Push(command);
            }

            return result;
        }
    }
}
