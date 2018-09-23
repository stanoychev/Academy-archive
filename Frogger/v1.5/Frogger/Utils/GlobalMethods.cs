using Frogger.Objects.Models;

namespace Frogger.Utils
{
    public static class GlobalMethods
    {
        public static int GetFrogMaxX()
        {
            return GlobalConstants.screenWidth - Frog.Instance.FrogDisplayLength - 1;
        }
    }
}
