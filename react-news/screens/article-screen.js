import React, { Component } from 'react';
import ArticleService from '../common/article-client';
import ComponentResolver from '../common/component-resolver';
const cr = new ComponentResolver();

import {
    ScrollView,
    ActivityIndicator ,
} from 'react-native';

export default class ListScreen extends Component {
    static navigationOptions = {
        title: 'The Times',
    }

    componentWillMount() {
        this.setState({articles: []});
    }

    componentDidMount() {
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
                const componentRendered = cr.renderComponent(componentRaw, i++);
                if (componentRendered != null) {
                    elems.push(componentRendered);
                }
            }
            return (
                <ScrollView style={{padding: 10 }} >
                    {elems}
                </ScrollView>
            )
        }
        return (
            <ActivityIndicator size='large' style={{margin: 50 }} />
        )
    }
};
