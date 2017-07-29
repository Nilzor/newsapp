import React, { Component } from 'react';
import {
    Text,
} from 'react-native';

export default class ComponentResolver {
    renderComponent(componentData, key) {
        if (componentData.type === 'text') {
            return (
                <Text key={key}>
                    {componentData.text.value}
                </Text>
            )
        }
        return null;
    }
}