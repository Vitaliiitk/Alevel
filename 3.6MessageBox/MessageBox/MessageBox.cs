namespace MessageBoxHomeTask
{
    public sealed class MessageBox
    {
        public event Action<StateEnum> WindowBeenClosed;

        public async void Open()
        {
            Console.WriteLine("Window is opened");

            await Task.Delay(3000);

            Console.WriteLine("Window was closed by the user");

            StateEnum state = GetRandomState();
            WindowBeenClosed?.Invoke(state);
        }

        private StateEnum GetRandomState()
        {
            var random = new Random();

            return (StateEnum)random.Next(0, 2);
        }
    }
}
