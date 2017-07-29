import React, { Component } from 'react';
import {
    StyleSheet,
    Text,
    View
    } from 'react-native';

export default class ArticleTeaser extends Component {
    render() {
        const article = this.props.article;
        var image = getFittingImage(article);
        // Improvement: Instead of wrapping flex's: https://codepen.io/vkjgr/pen/OPRPRR
        return (
            <View
                style={{flex: 1, flexDirection: 'row', justifyContent: 'center'}}>
                <Image
                    style={{width: 300, margin: 4}}
                    source={{uri: image.url}}
                    />
                <View style={{flex: 1, flexDirection: 'column'}}>
                    <Text style={styles.title}>{article.promotionContent.title.value}</Text>
                    <Text style={styles.description}>{article.promotionContent.description.value}</Text>
                </View>
            </View>

        )
    }

    getFittingImage(article) {
        const minWidth = 300;
        for (var asset in article.promotionContent.imageAsset) {
            if (asset.width > minWidth) {
                return asset;
            }
        }
        return null;
    }
}

const styles = StyleSheet.create({
    title: {
        margin: 4,
        fontWeight: "bold",
        fontSize: 16
    },
    description: {
        margin: 4,
        fontSize: 14
    },
});