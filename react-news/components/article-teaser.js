import React, { Component } from 'react';
import {
    StyleSheet,
    Text,
    View,
    Image,
    TouchableHighlight,
    } from 'react-native';
import commonStyles from '../styles/common';
import _ImageHelper from '../common/imagehelper';
const ImageHelper = new _ImageHelper();

export default class ArticleTeaser extends Component {
    render() {
        const article = this.props.article;
        const image = ImageHelper.getFittingImage(article.promotionContent.imageAsset, 300);
        // Improvement: Instead of wrapping flex's: https://codepen.io/vkjgr/pen/OPRPRR
        return (
            <TouchableHighlight onPress={() => this.onClick()} underlayColor="white">
                <View
                    style={[commonStyles.main, styles.containerStyle]}
                 >
                    <Image
                       style={{
                           width: 100,
                           height: undefined,
                           margin: 4,
                       }}
                       source={{uri: image.url}}
                       resizeMode='cover'
                    />
                    <View style={{flex: 1, flexDirection: 'column', justifyContent: 'flex-start'}}>
                        <Text style={[commonStyles.text, styles.title]}>{article.promotionContent.title.value}</Text>
                        <Text style={styles.description}>{article.promotionContent.description.value}</Text>
                    </View>
                </View>
            </TouchableHighlight>
        )
    }

    onClick() {
        if (this.props.onClick) {
            this.props.onClick(this.props.article.id);
        }
    }
}

const styles = StyleSheet.create({
    title: {
        margin: 4,
        fontWeight: "bold",
        fontSize: 18
    },
    description: {
        color: '#555',
        marginLeft: 4,
        marginRight: 4,
        marginBottom: 4,
        fontSize: 14
    },
    containerStyle: {
        flexDirection: 'row',
        //borderColor: '#ccc',
        //borderWidth: 1,
        margin: 4,
        // alignItems: 'flex-start'
    },
    separator: {
        borderBottomColor: '#ccc',
        borderBottomWidth: 6
    }
});