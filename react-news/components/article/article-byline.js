import React, { Component } from 'react';
import {
    Image,
    Text,
    View,
} from 'react-native';
import commonStyles from '../../styles/common';

export default class ByLine extends Component {
    render() {
        const data = this.props.data;
        var authorStr = " ";
        var i = 0 ;
        for (const author of data.authors) {
            if (i++ != 0) authorStr += ", ";
            authorStr += author.title;
        }

        return (
            <View>
               <Text style={[commonStyles.stdPadding, styles.by]}>By:
                   <Text style={[commonStyles.text, commonStyles.stdPadding, styles.names]}>{authorStr.toUpperCase()}</Text>
               </Text>
            </View>
        )
    }
}

const styles = {
    by: {
        paddingTop: 8,
        paddingBottom: 8,
        fontSize: 14,
        fontStyle: 'italic',
        paddingBottom: 2
    },
    names: {
        fontSize: 14,
        fontStyle: 'italic',
        color: 'red',
        paddingTop: 0,
    }
};