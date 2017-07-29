
import React, { Component } from 'react';
import ArticleService from '../common/article-client';

import {
    StyleSheet,
    ScrollView,
    Text,
    View,
    ActivityIndicator ,
} from 'react-native';

export default class ListScreen extends Component {
    componentWillMount() {
        this.setState({articles: []});
        const articleId = this.props.navigation.state.params.articleId;
        if (articleId != null) {
            ArticleService.getArticle(articleId).then(res => {
                this.setState({article: res});
            }).catch(err => {
                console.error(err);
            });
        }
    }

    render() {
        const elems = [];
        if (this.state.article) {
            var i = 0;
            for (let componentRaw of this.state.article.components) {
                const componentRendered = this.renderComponent(componentRaw, i++);
                if (componentRendered != null) {
                    elems.push(componentRendered);
                }
            }
            return (
                <ScrollView>
                    {elems}
                </ScrollView>
            )
        }
        return (
            <ActivityIndicator size='large' style={{margin: 50 }} />
        )
    }

    renderComponent(comp, key) {
        if (comp.type === 'text') {
            return (
                <Text key={key}>
                    {comp.text.value}
                </Text>
            )
        }
        return null;
    }
};
