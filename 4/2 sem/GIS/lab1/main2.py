import osgeo.ogr
shapefile = osgeo.ogr.Open("poland_airport_polygon.shp")
layer = shapefile. GetLayer(0)
feature = layer.GetFeature(12)
print("Геооб’єкт № 12 має наступні атрибути:")
print()
attributes = feature.items()
for key, value in attributes.items():
    print(" {} = {} " .format(key, value))
geometry = feature.GetGeometryRef()
geometryName = geometry.GetGeometryName()
print()
print("Геометрія заданного Геооб’єкту представляє собою {} ".format(
    geometryName))
geometryArea = geometry.GetArea()
print("З площею {} ".format(geometryArea))
