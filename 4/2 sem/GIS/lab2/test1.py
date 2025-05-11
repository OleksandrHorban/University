import pyproj
UTM_X = 565718.523517
UTM_Y = 3980998.9244
srcProj = pyproj.Proj(proj="utm", zone="17", ellps="clrk66", units="m")
dstProj = pyproj.Proj(proj='longlat', ellps='WGS84', datum='WGS84')
long, lat = pyproj.transform(srcProj, dstProj, UTM_X, UTM_Y)
print("Координата 17-ї зони UTM " +
    " ({:.4f}, {:.4f}) ".format(UTM_X, UTM_Y) + "= {:.4f}, {:.4f}".format(long, lat))