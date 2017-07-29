import React, { Component } from 'react';
import {
    Text,
} from 'react-native';

export default class ArticleText extends Component {
    render() {
        const data = this.props.data;
        return (
            <Text style={styles.standard}>
                {data.text.value}
            </Text>
        )
    }
}

const styles = {
    standard: {
        margin: 4
    }
};