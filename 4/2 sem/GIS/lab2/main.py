import pyproj
import osgeo.ogr
import math
from stufFunc import printLayers

shapefile = osgeo.ogr.Open("resource/gis_osm_natural_a_free_1.shp")
numLayers = shapefile.GetLayerCount()
printLayers(numLayers, shapefile)

layer = shapefile.GetLayer()
feature = layer.GetFeature(1111)
geometry = feature.GetGeometryRef()

# transfer
print(feature.GetField("NAME"))
X, Y, _ = geometry.Centroid().GetPoint()
print("X,Y = ({:.4f}, {:.4f}) ".format(X, Y))
utmProj = pyproj.Proj(proj="utm", zone="17", ellps="clrk66", units="m")
longlatProj = pyproj.Proj(proj='longlat', ellps='WGS84', datum='WGS84')
res_x, res_y = pyproj.transform(longlatProj, utmProj, X, Y)
print("Координата ({:.4f}, {:.4f}) ".format(X, Y) +
      "= ({:.4f}, {:.4f}) UTM".format(res_x, res_y))
print()

# Area
geometryArea = geometry.GetArea()
featureName = feature.GetField("NAME")
print(f"Об'єкт {featureName} має площину - {geometryArea}")
print()

