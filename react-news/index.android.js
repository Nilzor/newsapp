import React, { Component } from 'react';
import ArticleTeaser from './components/article-teaser';
import getAppState from './common/state';
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
class App extends React.Component {
    componentDidMount() {
        // Perform initial navigation
        loadState(this.navigator);
    }

    render() {
        return (
                <StackNav uriPrefix={uriPrefix}  ref={nav => { this.navigator = nav; }}  />
        );
    }
}

// Loads the state from permanent storage.
// Navigates to stored article ID, if any stored
const loadState = async (navigator) => {
    const storedState = await getAppState();
    console.log("Restored state: ", storedState)
    if (storedState && storedState.currentArticleId != null) {
        navigator.dispatch({
            type: 'Navigation/NAVIGATE',
            routeName: 'Article',
            params: {
                articleId: storedState.currentArticleId
            }
        });
    }
};

// Reset "current article id" after coming back from an article
const saveAppState = async() => {
    const appState = await getAppState();
    appState.currentArticleId = null;
    await appState.save();
};

const defaultGetStateForAction = StackNav.router.getStateForAction;

// Hook onto all navigation events
// Improvement point: Do all state saving here, remove from article-screen.js
StackNav.router.getStateForAction = (action, state) => {

    if (state) {
        var route = state.routes ? state.routes[state.index].routeName : "UNKNOWN";
        if (action.type === 'Navigation/BACK' && route === 'Article') {
            // Navigating BACK from Article
            saveAppState();
        }
    }

    return defaultGetStateForAction(action, state);
};


AppRegistry.registerComponent('reactnews', () => App);