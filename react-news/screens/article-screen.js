import React, { Component } from 'react';
import ArticleService from '../common/article-client';
import ComponentResolver from '../common/component-resolver';
const cr = new ComponentResolver();
import getAppState from '../common/state';
import commonStyles from '../styles/common';

import {
    ScrollView,
    ActivityIndicator ,
} from 'react-native';

export default class ArticleScreen extends Component {
    static navigationOptions = {
        title: 'The Times',
        headerStyle: commonStyles.actionBar
    }

    componentWillMount() {
        this.setState({});
    }

    componentDidMount() {
        const articleId = this.props.navigation.state.params.articleId;
        if (articleId == null) console.error('No article ID specified for ArticleScreen');
        if (articleId != null) {
            console.log('Loading article ' + articleId);
            ArticleService.getArticle(articleId).then(res => {
                console.log('Article loaded');
                this.setState({article: res});
                this.saveAppState();
            }).catch(err => {
                console.error(err);
            });
        }
    }

    async saveAppState() {
        const appState = await getAppState();
        console.log('saveAppState: ', appState);
        appState.currentArticleId = this.state.article.id;
        if (appState.currentArticleId != null) {
            await appState.save();
        }
    }

    render() {
        const elems = [];
        if (this.state.article) {
            var i = 0;
            for (let componentRaw of this.state.article.components) {
                const componentRendered = cr.renderComponent(componentRaw, i++);
                console.log('Adding component ' + i + ': ' + componentRaw.type);
                if (componentRendered != null) {
                    elems.push(componentRendered);
                }
            }
            return (
                <ScrollView style={commonStyles.main} >
                    {elems}
                </ScrollView>
            )
        }
        return (
            <ActivityIndicator size='large' style={{margin: 50 }} />
        )
    }
};
