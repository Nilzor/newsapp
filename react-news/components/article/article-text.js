import React, { Component } from 'react';
import {
    Text,
} from 'react-native';

export default class ArticleText extends Component {
    render() {
        const data = this.props.data;
        var style = styles.standard;
        switch (data.subtype) {
            case 'heading': style = styles.heading; break;
            case 'title': style = styles.title; break;
            case 'lead': style = styles.lead; break;
            case 'blockquote': style = styles.blockquote; break;
        }

        return (
            <Text style={style}>
                {data.text.value}
            </Text>
        )
    }
}

const styles = {
    standard: {
        margin: 4,
        fontSize: 14,
    },
    title: {
        margin: 4,
        fontSize: 22,
        fontWeight: 'bold',
    },
    lead: {
        margin: 4,
        fontWeight: 'bold',
        fontSize: 16,
    },
    heading: {
        margin: 4,
        fontWeight: 'bold',
        fontSize: 16,
    },
    blockquote: {
        margin: 4,
        fontStyle: 'italic',
        fontSize: 14,
    },

};