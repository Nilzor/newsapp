import React, { Component } from 'react';
import {
    Image,
} from 'react-native';
import _ImageHelper from '../../common/imagehelper';
const ImageHelper = new _ImageHelper();

export default class ArticleImage extends Component {
    render() {
        const data = this.props.data;
        const image = ImageHelper.getFittingImage(data.imageAsset, 999999);
        return (
            <Image
                style={{
                   width: 400,
                   height: 200,
                   margin: 4,
                   borderWidth: 1,
                   borderColor: '#777',
               }}
                source={{uri: image.url}}
            >
            </Image>
        )
    }
}

const styles = {
    standard: {
        margin: 4
    }
};