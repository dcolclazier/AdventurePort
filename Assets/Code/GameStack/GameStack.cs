using System.Collections.Generic;
using System.Linq;

namespace Assets.Code.Scripts
{
    public class GameStack
    {
        private readonly List<IBlock> _stackList;

        public GameStack()
        {
            _stackList = new List<IBlock>();
        }
        public void Push(IBlock block)
        {
            _stackList.Add(block);   
        }

        public IBlock Pop()
        {
            if (_stackList.Count == 0) return null;

            var blockToPop = _stackList.ElementAt(_stackList.Count - 1);
            _stackList.RemoveAt(_stackList.Count-1);
            return blockToPop;
        }
    }
}