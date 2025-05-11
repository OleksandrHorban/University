import matplotlib.pyplot as plt
import geopandas as gpd
import osgeo.ogr
from stufFunc import printLayers,printFeatureName

path_to_file = "resource/gis_osm_natural_a_free_1.shp"
shapefile = osgeo.ogr.Open(path_to_file)
numLayers = shapefile.GetLayerCount()
printLayers(numLayers, shapefile)
printFeatureName(shapefile)

lsoas = gpd.read_file(path_to_file)
print(lsoas.head())
lsoas.plot()
plt.show()