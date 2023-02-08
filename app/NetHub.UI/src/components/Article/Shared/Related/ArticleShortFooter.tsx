import React, { FC } from 'react';
import cl from "../ArticleShort.module.sass";
import ArticlesRateCounter from "../ArticlesRateCounter";
import ArticleSavingActions from "../ArticleSavingActions";
import { Box, Text } from "@chakra-ui/react";
import Actions from "../../../UI/Action/Actions";
import { IArticleLocalizationModel, Vote } from "../../../../api/_api";

interface IArticleShortFooterProps {
  localization: IArticleLocalizationModel,
  save: { actual: boolean, handle: () => Promise<void> },

  updateCounter: (rate: number, vote: Vote | null) => void,

  afterCounterRequest: () => Promise<void>,

  variant?: 'default' | 'created'
}

const ArticleShortFooter: FC<IArticleShortFooterProps> =
  ({localization, save, updateCounter, afterCounterRequest, variant}) => {

    const addLocalizationHandle = (e: React.MouseEvent<HTMLDivElement>) => {
      e.stopPropagation()
      alert('add article localization')
    }

    return (
      <div className={cl.actions}>
        <Box display={'flex'}>
          <ArticlesRateCounter
            rate={localization.rate}
            articleId={localization.articleId}
            vote={localization.vote}
            updateCounter={updateCounter}
            afterRequest={afterCounterRequest}
          />
          {(variant ?? 'default') === 'created'
            ? <Actions onClick={addLocalizationHandle}>
              <Text as={'p'} color={'black'}>Додати переклад +</Text>
            </Actions>
            : null
          }
        </Box>
        <ArticleSavingActions
          isSavedDefault={save.actual}
          onSave={save.handle}
          saveLink={`${window.location.href}article/${localization.articleId}/${localization.languageCode}`}
        />
      </div>
    );
  };

export default ArticleShortFooter;