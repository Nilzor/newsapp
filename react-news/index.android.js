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

const App = StackNavigator({
    Home: { screen: ListScreen },
    Article: { screen: ArticleScreen },
}, {
    headerMode: 'screen' // Other options: float and none
});

AppRegistry.registerComponent('reactnews', () => App);