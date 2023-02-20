using System.Net;

class GrahamConvexHull : IConvexHullAlgorithm
{

    public List<IntPoint> FindHull(List<IntPoint> points)
    {
        if (points.Count <= 3)
        {
            return new List<IntPoint>(points);
        }

        int firstCornerIndex = 0;
        IntPoint pointFirstCorner = points[0];

        for (int i = 1, n = points.Count; i < n; i++)
        {
            if ((points[i].X < pointFirstCorner.X) ||
                ((points[i].X == pointFirstCorner.X) && (points[i].Y < pointFirstCorner.Y)))
            {
                pointFirstCorner = points[i];
                firstCornerIndex = i;
            }
        }

        PointToProcess firstCorner = new PointToProcess(pointFirstCorner);
        PointToProcess[] arrPointsToProcess = new PointToProcess[points.Count - 1];
        for (int i = 0; i < points.Count - 1; i++)
        {
            IntPoint point = points[i >= firstCornerIndex ? i + 1 : i];
            arrPointsToProcess[i] = new PointToProcess(point);
        }

        for (int i = 0, n = arrPointsToProcess.Length; i < n; i++)
        {
            int dx = arrPointsToProcess[i].X - firstCorner.X;
            int dy = arrPointsToProcess[i].Y - firstCorner.Y;

            arrPointsToProcess[i].Distance = dx * dx + dy * dy;
            arrPointsToProcess[i].K = (dx == 0) ? float.PositiveInfinity : (float)dy / dx;
        }

        Array.Sort(arrPointsToProcess);
        Queue<PointToProcess> queuePointsToProcess = new Queue<PointToProcess>(arrPointsToProcess);
        LinkedList<PointToProcess> convexHullTemp = new LinkedList<PointToProcess>();
        PointToProcess prevPoint = convexHullTemp.AddLast(firstCorner).Value;
        PointToProcess lastPoint = convexHullTemp.AddLast(queuePointsToProcess.Dequeue()).Value;

        while (queuePointsToProcess.Count != 0)
        {
            PointToProcess newPoint = queuePointsToProcess.Peek();

            if ((newPoint.K == lastPoint.K) || (newPoint.Distance == 0))
            {
                queuePointsToProcess.Dequeue();
                continue;
            }

            if ((newPoint.X - prevPoint.X) * (lastPoint.Y - newPoint.Y) - (lastPoint.X - newPoint.X) * (newPoint.Y - prevPoint.Y) < 0)
            {
                convexHullTemp.AddLast(newPoint);
                queuePointsToProcess.Dequeue();

                prevPoint = lastPoint;
                lastPoint = newPoint;
            }
            else
            {
                convexHullTemp.RemoveLast();

                lastPoint = prevPoint;
                prevPoint = convexHullTemp.Last.Previous.Value;
            }
        }

        List<IntPoint> convexHull = new List<IntPoint>();

        foreach (PointToProcess pt in convexHullTemp)
        {
            convexHull.Add(pt.ToPoint());
        }

        return convexHull;
    }

    private class PointToProcess : IComparable
    {
        public int X;
        public int Y;
        public float K;
        public float Distance;

        public PointToProcess(IntPoint point)
        {
            X = point.X;
            Y = point.Y;

            K = 0;
            Distance = 0;
        }

        public int CompareTo(object obj)
        {
            PointToProcess another = (PointToProcess)obj;

            return (K < another.K) ? -1 : (K > another.K) ? 1 :
                ((Distance > another.Distance) ? -1 : (Distance < another.Distance) ? 1 : 0);
        }

        public IntPoint ToPoint()
        {
            return new IntPoint(X, Y);
        }
    }

}

class IntPoint
{
    public int X { get; private set; }
    public int Y { get; private set; }
    public IntPoint(int x, int y)
    {
        X = x;
        Y = y;
    }
}