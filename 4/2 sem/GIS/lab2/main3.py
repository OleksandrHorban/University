import matplotlib.pyplot as plt
import geopandas as gpd

lsoas = gpd.read_file("resource/gis_osm_roads_free_1.shp")
print(lsoas.head())
res = lsoas.query('maxspeed >= 60')
res.plot()
plt.show()