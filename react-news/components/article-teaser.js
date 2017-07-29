import React, { Component } from 'react';
import {
    StyleSheet,
    Text,
    View,
    Image,
    TouchableHighlight,
    } from 'react-native';

export default class ArticleTeaser extends Component {
    render() {
        const article = this.props.article;
        const image = this.getFittingImage(article);
        // Improvement: Instead of wrapping flex's: https://codepen.io/vkjgr/pen/OPRPRR
        return (
            <TouchableHighlight onPress={() => this.onClick()} underlayColor="white">
                <View
                    style={{
                        flex: 1,
                        flexDirection: 'row',
                        //borderColor: '#ccc',
                        //borderWidth: 1,
                        margin: 4,
                        shadowColor: '#777',
                        // alignItems: 'flex-start'
                    }}
                 >
                    <Image
                       style={{
                           width: 100,
                           height: undefined,
                           margin: 4,
                           borderWidth: 1,
                           borderColor: '#777',
                       }}
                       source={{uri: image.url}}
                       resizeMode='center'
                    />
                    <View style={{flex: 1, flexDirection: 'column', justifyContent: 'flex-start'}}>
                        <Text style={styles.title}>{article.promotionContent.title.value}</Text>
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

    getFittingImage(article) {
        const minWidth = 300;
        for (var asset of article.promotionContent.imageAsset.urls) {
            if (asset.width > minWidth) {
                return asset;
            }
        }
        return {};
    }
}

const styles = StyleSheet.create({
    title: {
        margin: 4,
        fontWeight: "bold",
        fontSize: 16
    },
    description: {
        marginLeft: 4,
        marginRight: 4,
        marginBottom: 4,
        fontSize: 14
    },
});