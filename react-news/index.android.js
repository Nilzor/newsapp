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
    View
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
            <View style={styles.container}>
                <Text style={styles.welcome}>
                    Article IDs:{"\n"}
                    {ids}
                </Text>
            </View>
        );
    }
}

const styles = StyleSheet.create({
    container: {
        flex: 1,
        justifyContent: 'center',
        alignItems: 'center',
        backgroundColor: '#F5FCFF',
    },
    welcome: {
        fontSize: 20,
        textAlign: 'center',
        margin: 10,
    },
    instructions: {
        textAlign: 'center',
        color: '#333333',
        marginBottom: 5,
    },
});

AppRegistry.registerComponent('reactnews', () => reactnews);
