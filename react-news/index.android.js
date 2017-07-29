/**
 * Sample React Native App
 * https://github.com/facebook/react-native
 * @flow
 */

import React, { Component } from 'react';
import ArticleService from './common/article-client';
import ArticleTeaser from './components/article-teaser';
import {
    AppRegistry,
    StyleSheet,
    Text,
    ScrollView,
    View,
    } from 'react-native';

export default class reactnews extends Component {

    componentWillMount() {
        this.setState({articles: []});
        ArticleService.getArticleList().then(res => {
            this.setState({articles: res});
        });
    }

    render() {
        let ids = [];
        for (let article of this.state.articles) {
            ids.push(<ArticleTeaser article={article} key={article.id}/>)
        }
        return (
            <ScrollView style={styles.container}>
                <Text style={styles.header}>Latest news:</Text>
                {ids}
            </ScrollView>
        );
    }
}

const styles = StyleSheet.create({
    container: {
        flex: 1,
        backgroundColor: '#F5FCFF',
        margin: 10,
    },
    header: {
        fontSize: 20,
        fontWeight: 'bold',
        margin: 4,
    },
});

AppRegistry.registerComponent('reactnews', () => reactnews);
