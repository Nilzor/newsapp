import React, { Component } from 'react';

import ArticleText from '../components/article/article-text';

export default class ComponentResolver {
    renderComponent(componentData, key) {
        switch (componentData.type) {
            case 'text' : return (
                <ArticleText data={componentData} key={key} />  
            )
        }
        return null;
    }
}