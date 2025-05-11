import osgeo.ogr
import math


def findMaxMinYPoints(geometry, results):
    for i in range(geometry.GetPointCount()):
        x, y, z = geometry.GetPoint(i)
        if results['north'] == None or results['north'][1] < y:
            results['north'] = (x, y)
        if results['south'] == None or results['south'][1] > y:
            results['south'] = (x, y)
    for i in range(geometry.GetGeometryCount()):
        findMaxMinYPoints(geometry.GetGeometryRef(i), results)


def findMaxMinXPoints(geometry, results):
    for i in range(geometry.GetPointCount()):
        x, y, z = geometry.GetPoint(i)
        if results['west'] == None or results['west'][0] > x:
            results['west'] = (x, y)
        if results['east'] == None or results['east'][0] < x:
            results['east'] = (x, y)
    for i in range(geometry.GetGeometryCount()):
        findMaxMinXPoints(geometry.GetGeometryRef(i), results)


def calcDistance(pointA, pointB):
    longl = pointA[0]
    latl = pointA[1]
    long2 = pointB[0]
    lat2 = pointB[1]
    rLatl = math.radians(latl)
    rLongl = math.radians(longl)
    rLat2 = math.radians(lat2)
    rLong2 = math.radians(long2)
    dLat = rLat2 - rLatl
    dLong = rLong2 - rLongl
    a = math.sin(dLat / 2) ** 2 + math.cos(rLatl) * \
        math.cos(rLat2) * math.sin(dLong/2)**2
    c = 2 * math.atan2(math.sqrt(a), math.sqrt(1-a))
    distance = 6371 * c
    print(
        "Відстань по дузі великого кола складає {:0.0f} км.".format(distance))
    return distance


def getAVGPoint(pointA, pointB):
    return ((pointA[0]+pointB[0])/2, (pointA[1]+pointB[1])/2)


shapefile = osgeo.ogr.Open("poland_airport_polygon.shp")
layer = shapefile.GetLayer(0)
feature = layer.GetFeature(13)
geometry = feature.GetGeometryRef()

resultsY = {'north': None, 'south': None}
findMaxMinYPoints(geometry, resultsY)
print("Найпівнічніша точка: ( {:.4f}, {:.4f})".format(
    resultsY['north'][0], resultsY['north'][1]))
print("найпівденніша точка: ( {:.4f}, {:.4f})".format(
    resultsY['south'][0], resultsY['south'][1]))
avgPointY = getAVGPoint(resultsY['north'], resultsY['south'])

resultsX = {'west': None, 'east': None}
findMaxMinXPoints(geometry, resultsX)
print("Найзахідніша точка: ({:.4f}, {:.4f})".format(
    resultsX['west'][0], resultsX['west'][1]))
print("Найсхідніша точка: ({:.4f}, {:.4f})".format(
    resultsX['east'][0], resultsX['east'][1]))
avgPointX = getAVGPoint(resultsX['west'], resultsX['east'])

avgPoint = getAVGPoint(avgPointX, avgPointY)
print("Середня точка: ({:.4f}, {:.4f}) для об'єкту ".format(avgPoint[0], avgPoint[1]) + feature.GetField("NAME"))
dist = calcDistance(resultsY['north'], resultsY['south'])
print(f"Дистанція між павнічною і південною точкою: {dist}")