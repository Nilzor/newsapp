import React, { Component } from 'react';
import {
    Image,
    Text,
    View,
} from 'react-native';
import _ImageHelper from '../../common/imagehelper';
import commonStyles from '../../styles/common';
const ImageHelper = new _ImageHelper();

export default class ArticleImage extends Component {
    render() {
        const data = this.props.data;
        const image = ImageHelper.getFittingImage(data.imageAsset, 999999);
        return (
            <View>
                <Image
                    style={{
                       width: 400,
                       height: 200,
                       marginTop: 4,
                       marginBottom: 4,
                       borderWidth: 1,
                       resizeMode: 'contain',
                       borderColor: '#777',
                   }}
                    source={{uri: image.url}}
                >
                </Image>
                <Text style={[commonStyles.text, commonStyles.stdPadding, styles.caption]}>
                    {data.caption.value}
                </Text>
                <Text style={[commonStyles.text, commonStyles.stdPadding, styles.byLine]}>
                    {data.byline.title}
                </Text>
            </View>
        )
    }
}

const styles = {
    caption: {
        fontSize: 14,
        fontStyle: 'italic',
        paddingBottom: 2
    },
    byLine: {
        fontSize: 14,
        fontStyle: 'italic',
        color: "#555",
        paddingTop: 0
    }
};