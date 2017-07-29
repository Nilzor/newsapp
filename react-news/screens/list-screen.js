
import React, { Component } from 'react';
import ArticleService from '../common/article-client';
import ArticleTeaser from '../components/article-teaser';import {
    StackNavigator,
    } from 'react-navigation';

import {
    AppRegistry,
    StyleSheet,
    Text,
    ScrollView,
    View,
    ActivityIndicator,
} from 'react-native';

const styles = StyleSheet.create({
    container: {
        flex: 1,
        backgroundColor: '#F5FCFF',
        margin: 10,
    },
    header: {
        color: '#000',
        fontSize: 20,
        fontWeight: 'bold',
        margin: 4,
    },
});

export default class ListScreen extends Component {
    componentWillMount() {
        this.setState({articles: []});
        ArticleService.getArticleList().then(res => {
            this.setState({articles: res});
        });
    }

    render() {
        let ids = [];
        for (let article of this.state.articles) {
            ids.push(<ArticleTeaser article={article} key={article.id} onClick={() => this.onArticleClicked(article.id)}/>)
        }
        var progressIndicator = null;
        if (this.state.articles.length === 0) {
            progressIndicator = <ActivityIndicator size='large' style={{margin: 50 }} />
        }
        return (
            <ScrollView style={styles.container}>
                <Text style={styles.header}>Latest news:</Text>
                {progressIndicator}
                {ids}
            </ScrollView>
        );
    }

    onArticleClicked(articleId) {
        const { navigate } = this.props.navigation;
        navigate('Article', { articleId: articleId });
    }
}

