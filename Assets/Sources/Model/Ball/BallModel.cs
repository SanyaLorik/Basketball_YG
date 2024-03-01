using Basketball_YG.View;

namespace Basketball_YG.Model
{
    public abstract class BallModel : TransformableModel
    {
        public BallModel(ITransformableView view) : base(view) { }
    }
    
    /*public class SimpleBallModel : BallModel
    {

    }*/
}