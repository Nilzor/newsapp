

export default class ImageHelper {
    getFittingImage(imageAsset, minWidth) {
        var lastImage = null;
        for (var asset of imageAsset.urls) {
            if (asset.width > minWidth) {
                return asset;
            }
            lastImage = asset;
        }
        return lastImage;
    }
}