import osgeo.ogr
import matplotlib.pyplot as plt
import geopandas as gpd
from stufFunc import printLayers, getRoadLength

path_to_file = "resource/gis_osm_roads_free_1.shp"
shapefile = osgeo.ogr.Open(path_to_file)
numLayers = shapefile.GetLayerCount()
printLayers(numLayers, shapefile)

road_layer = shapefile.GetLayer()

# getRoadLength(road_layer)

query = 'maxspeed >= 60'
# # filters
print("Feture where ",query)
road_layer.SetAttributeFilter(query)
count=0
for feature in road_layer:
    count+=1
road_layer.ResetReading()
print("count = ", count)

getRoadLength(road_layer)

# plot - use main3.py