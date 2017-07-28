/**
 * Sample React Native App
 * https://github.com/facebook/react-native
 * @flow
 */

import React, { Component } from 'react';
import ArticleService from './common/article-client';
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
            console.warn(JSON.stringify(res[0].id));
            this.setState({articles: res});
        });
    }

    render() {
        return (
            <View style={styles.container}>
                <Text style={styles.welcome}>
                    Article IDs:
                    {
                        this.state.articles.length > 0 ? this.state.articles[0].id : ""
                    }
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
