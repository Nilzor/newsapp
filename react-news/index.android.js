import React, { Component } from 'react';
import ArticleTeaser from './components/article-teaser';
import {
    StackNavigator,
} from 'react-navigation';

import {
    AppRegistry,
} from 'react-native';

import ListScreen from './screens/list-screen';
import ArticleScreen from './screens/article-screen';

const StackNav = StackNavigator({
    Home: { screen: ListScreen },
    Article: {
        screen: ArticleScreen,
        // Test path with for instance 'adb shell am start "news://app/article/8yk1E"'
        path: 'article/:articleId',
    },
}, {
    headerMode: 'screen' // Other options: float and none
});

const uriPrefix = 'news://app/';
const App = () => <StackNav uriPrefix={uriPrefix}/>

AppRegistry.registerComponent('reactnews', () => App);