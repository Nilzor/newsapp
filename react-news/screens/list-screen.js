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
import commonStyles from '../styles/common';

const styles = StyleSheet.create({
    container: {
        flex: 1
    },
    header: {
        color: '#000',
        fontSize: 20,
        fontWeight: 'bold',
        margin: 4,
    },
});

export default class ListScreen extends Component {
    // Read more about navigation configuration at
    // https://reactnavigation.org/docs/navigators/stack
    static navigationOptions = {
        title: 'The Times',
        headerStyle: commonStyles.actionBar
    };

    componentWillMount() {
        this.setState({articles: []});
    }

    componentDidMount() {
        if (this.state.articles.length === 0) {
            ArticleService.getArticleList().then(res => {
                this.setState({articles: res});
            });
        }
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
            <ScrollView style={commonStyles.main}>
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

