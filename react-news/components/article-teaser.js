
import React, { Component } from 'react';
import {
    StyleSheet,
    Text,
    View
    } from 'react-native';
export default class ArticleTeaser extends Component {
    render() {
        const article = this.props.article;
        return (
            <Text style={styles.text}>{article.promotionContent.title.value}{'\n'}{'\n'}</Text>
        )
    }
}

const styles = StyleSheet.create({
    text: {
    }
});