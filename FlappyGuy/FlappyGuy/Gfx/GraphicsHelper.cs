using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;

namespace Hweny.FlappyGuy.Gfx
{
    public struct TransformableEntity
    {
        public static readonly TransformableEntity Empty = new TransformableEntity(0f, 1f, 1f, FlipMode.FlipNone);

        public float Rotate;
        public float Scale;
        public float Alpha;
        public FlipMode Flip;

        public TransformableEntity(float rotate = 0f,
            float scale = 1f, float alpha = 1f, FlipMode flip = FlipMode.FlipNone)
        {
            Rotate = rotate;
            Scale = scale;
            Alpha = alpha;
            Flip = flip;
        }
    }

    public enum FlipMode
    {
        FlipNone,
        FlipX,
        FlipY,
        FlipXY
    }

    public class GraphicsHelper
    {
        public static void AlphaBlend(Graphics g, Image image, RectangleF dest, RectangleF src, float alpha)
        {
            if (image == null) return;

            if (alpha >= 1f)
            {
                g.DrawImage(image, dest, src, GraphicsUnit.Pixel);
                return;
            }

            ColorMatrix cm = new ColorMatrix(
                  new float[][]{
                    new float[]{1f,0,0,0,0},
                    new float[]{0,1f,0,0,0},
                    new float[]{0,0,1f,0,0},
                    new float[]{0,0,0,alpha,0},
                    new float[]{0,0,0,0,1f}
                }
            );

            ImageAttributes imageAttr = new ImageAttributes();
            imageAttr.SetColorMatrix(cm, ColorMatrixFlag.Default, ColorAdjustType.Bitmap);
            g.CompositingMode = System.Drawing.Drawing2D.CompositingMode.SourceOver;
            g.CompositingQuality = System.Drawing.Drawing2D.CompositingQuality.HighQuality;

            PointF[] destPt ={
                new PointF(dest.X,dest.Y),
                new PointF(dest.Right,dest.Y),
                new PointF(dest.X,dest.Bottom)
            };
            g.DrawImage(image, destPt, src, GraphicsUnit.Pixel, imageAttr);
            imageAttr.Dispose();
            imageAttr = null;
        }

        public static void DrawImage(Graphics g, Image image, RectangleF dest, RectangleF src,
            float rotate = 0f, float scale = 1f, float alpha = 1f, FlipMode flip = FlipMode.FlipNone)
        {
            if (image == null) return;

            Matrix m = null;
            if (flip == FlipMode.FlipNone)
                m = new Matrix(1 * scale, 0, 0, 1 * scale, dest.X, dest.Y);
            else if (flip == FlipMode.FlipX)
                m = new Matrix(-1 * scale, 0, 0, 1 * scale, dest.X + dest.Width * scale, dest.Y);
            else if (flip == FlipMode.FlipY)
                m = new Matrix(1 * scale, 0, 0, -1 * scale, dest.X, dest.Y + dest.Height * scale);
            else if (flip == FlipMode.FlipXY)
                m = new Matrix(-1 * scale, 0, 0, -1 * scale, dest.X + dest.Width * scale, dest.Y + dest.Height * scale);

            dest.X = dest.Y = 0f;
            m.RotateAt(rotate, new PointF(dest.X + dest.Width / 2, dest.Y + dest.Height / 2));
            g.Transform = m;
            AlphaBlend(g, image, dest, src, alpha);
            g.ResetTransform();
            m.Dispose();
            m = null;
        }

        public static void DrawImage(Graphics g, Image image,
            float x, float y, float rotate = 0f, float scale = 1f, float alpha = 1f, FlipMode flip = FlipMode.FlipNone)
        {
            if (image == null) return;

            RectangleF dest = new RectangleF(x, y, image.Width, image.Height);
            RectangleF src = new RectangleF(0, 0, dest.Width, dest.Height);
            DrawImage(g, image, dest, src, rotate, scale, alpha, flip);
        }

        public static void DrawImage(Graphics g, Image image, RectangleF dest, RectangleF src,
            TransformableEntity transformEntity)
        {
            DrawImage(g, image, dest, src, transformEntity.Rotate, transformEntity.Scale, transformEntity.Alpha, transformEntity.Flip);
        }

        public static void DrawImage(Graphics g, Image image,
            float x, float y, TransformableEntity transformEntity)
        {
            DrawImage(g, image, x, y, transformEntity.Rotate, transformEntity.Scale, transformEntity.Alpha, transformEntity.Flip);
        }

        public static void DrawImage(Graphics g, Image image,
            PointF pt, TransformableEntity transformEntity)
        {
            DrawImage(g, image, pt.X, pt.Y, transformEntity);
        }
    }
}
