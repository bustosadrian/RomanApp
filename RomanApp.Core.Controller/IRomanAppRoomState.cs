using Reedoo.NET.Controller;

namespace RomanApp.Core.Controller
{
    public interface IRomanAppRoomState
    {
        void OnExit(IMember member);
    }
}
