import React, { Component } from 'react';
import {
    Text,
} from 'react-native';
import commonStyles from '../../styles/common';

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
            <Text style={[commonStyles.stdPadding, commonStyles.text, style]}>
                {data.text.value}
            </Text>
        )
    }
}

const styles = {
    standard: {
        fontSize: 18,
    },
    title: {
        fontSize: 28,
        fontWeight: 'bold',
        fontFamily: 'serif',
    },
    lead: {
        fontWeight: 'bold',
        fontSize: 18,
    },
    heading: {
        fontWeight: 'bold',
        fontSize: 18,
    },
    blockquote: {
        fontStyle: 'italic',
        textColor: '#d00',
        fontSize: 28,
    },

};