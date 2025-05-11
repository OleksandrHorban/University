import osgeo.ogr
import math

def printLayers(numLayers, shapefile):
    print("Файл фігур містить {} шарів".format(numLayers))
    for layerNum in range(numLayers):
        layer = shapefile.GetLayer(layerNum)
        spatialRef = layer.GetSpatialRef().ExportToProj4()
        numFeatures = layer.GetFeatureCount()
        print("шар {} має просторову прив’язку {}".format(layerNum, spatialRef))
        print("шар {} містить {} геооб’єктів: ".format(layerNum, numFeatures))
        print()
        # for featureNum in range(numFeatures):
        #     feature = layer.GetFeature(featureNum)
        #     featureName = feature.GetField("NAME")
        #     print("Геооб’єкт {} під назвою {}". format(featureNum, featureName))


def printFeatureName(shapefile):
    road_layer = shapefile.GetLayer()
    for feature in road_layer:    
        for key, val in zip(feature.items(), feature):
            print(key, " - ", val)
        break


def getRoadLength(road_layer):
    # road length
    total_length = 0
    for feature in road_layer:
        geometry = feature.GetGeometryRef()
        length = geometry.Length()
        total_length += length

    print(f'Total road length: {total_length}')
    road_layer.ResetReading()
    return total_length
